using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mars.Common.UnitOfWork;
using pluton.dal.Entities;
using pluton.dal.UnitOfWork;
using pluton.web.Data;

namespace pluton.web.Infrastructure
{
    public static class Localization
    {
        //culture, list of transaltions
        private static readonly Dictionary<string, List<LocalizationResource>> Translations;
        private static readonly object SyncObject = new object();

        static Localization()
        {
            Translations = new Dictionary<string, List<LocalizationResource>>();
        }

        public static string Translate(string value, string lang)
        {
            lock (SyncObject)
            {
                if (Translations.ContainsKey(lang))
                {
                    return GetTranslationValue(lang, value);
                }
                using (var unitOfWork = new UnitOfWork(new PlutonContext()))
                {
                    //get tranlations list
                    var translations = unitOfWork.Repository<LocalizationResource>()
                                                 .Query()
                                                 .Filter(x => x.Culture == lang)
                                                 .Get().ToList();
                    // Translations don't contains lang because of conditions above.
                    Translations.Add(lang, translations);

                    return GetTranslationValue(lang, value);
                }
            }
        }

        private static string GetTranslationValue(string culture, string name)
        {
            if (Translations.ContainsKey(culture))
            {
                var translation = Translations[culture].FirstOrDefault(x => x.Name != null && x.Name.ToUpperInvariant() == name.ToUpperInvariant());
                if (translation == null)
                {
                    AddNewValue(name, culture);
                    return name;
                }
                return translation.Value;
            }

            AddNewValue(name, culture);
            return name;
        }

        private static void AddNewValue(string name, string culture)
        {
            //add new value
            //We should add this value to CURRENT culture. Not for all.
            using (var unitOfWork = new UnitOfWork(new PlutonContext()))
            {
                unitOfWork.Repository<LocalizationResource>().Insert(new LocalizationResource()
                {
                    Culture = culture,
                    Name = name,
                    Value = name,
                    DateTime = DateTime.Now,
                });

                unitOfWork.Commit();

                if (!Translations.ContainsKey(culture))
                    Translations.Add(culture, new List<LocalizationResource>());

                Translations[culture].Add(new LocalizationResource
                {
                    Culture = culture,
                    Name = name,
                    Value = name
                });
            }
        }

        // I think we don't need to  preload languages. the Native language for current user will be loaded with first access to localize resource.
        // And Usual user don't change the language during his session.
        // Furthermore not necessary to load ALL languages. As result - low performance during loading app. And also we load to much in memory.


        public static string GetCurrentLanguage(HttpContextBase context)
        {
            var culture = Localization.DefaultLocalization;
            if (context.Request.Cookies["lang"] == null)
            {
                //add default
                context.Response.Cookies.Add(new HttpCookie("lang", culture));
            }
            else
            {
                culture = context.Request.Cookies["lang"].Value;
            }
            // Better to load from db actual data
            using (var unitOfWork = new UnitOfWork(new PlutonContext()))
            {
                if (unitOfWork.Repository<LocalizationResource>().Query().Filter(x => x.Culture == culture).GetOne() ==
                    null)
                {
                    context.Response.Cookies.Remove("lang");
                    context.Response.Cookies.Add(new HttpCookie("lang", DefaultLocalization));
                }
            }
           
            return culture;
        }

        public static string DefaultLocalization
        {
            get { return "pl"; }
        }
    }
}