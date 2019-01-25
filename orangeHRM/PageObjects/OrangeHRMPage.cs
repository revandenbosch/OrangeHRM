using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using AutomationFramework;
using SeleniumExtras.PageObjects;
using System.IO;
using System.Linq;

namespace OrangeHRM.PageObjects
{
    public class OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.ClassName, Using = "panelTrigger")]
        [CacheLookup]
        private IWebElement Welcome { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/index.php/auth/logout']")]
        [CacheLookup]
        private IWebElement LogoutButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnAdd")]
        [CacheLookup]
        public IWebElement AddBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnDelete")]
        [CacheLookup]
        public IWebElement DeleteBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnSave")]
        [CacheLookup]
        public IWebElement SaveBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancel")]
        [CacheLookup]
        public IWebElement CancelBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnEdit")]
        [CacheLookup]
        public IWebElement EditBtn { get; set; }

        #endregion

        public int SearchForRowContainingRecord(string searchCriteria, string tableNameID)
        {
            _logger.Info("Entering SearchForRow()");
            Table w3cTable = new Table(_driver.FindElement(By.Id(tableNameID)));
            _logger.Info($"Locating the {tableNameID} table.");
            try
            {
                int tableRow = w3cTable.FindFirstRowIndexByKnownValue(searchCriteria);
                _logger.Info($"Row containing {searchCriteria} found.");
                return tableRow;
            }
            catch
            {
                _logger.Info($"The Row containing {searchCriteria} was not found.");
                throw new Exception($"The Row containing {searchCriteria} was not found.");
            }
        }

        public static string StateAbbreviationExpand(string abbr)
        {
            Dictionary<string, string> states = new Dictionary<string, string>();

            states.Add("AL", "Alabama");
            states.Add("AK", "Alaska");
            states.Add("AZ", "Arizona");
            states.Add("AR", "Arkansas");
            states.Add("CA", "California");
            states.Add("CO", "Colorado");
            states.Add("CT", "Connecticut");
            states.Add("DE", "Delaware");
            states.Add("DC", "District of Columbia");
            states.Add("FL", "Florida");
            states.Add("GA", "Georgia");
            states.Add("HI", "Hawaii");
            states.Add("ID", "Idaho");
            states.Add("IL", "Illinois");
            states.Add("IN", "Indiana");
            states.Add("IA", "Iowa");
            states.Add("KS", "Kansas");
            states.Add("KY", "Kentucky");
            states.Add("LA", "Louisiana");
            states.Add("ME", "Maine");
            states.Add("MD", "Maryland");
            states.Add("MA", "Massachusetts");
            states.Add("MI", "Michigan");
            states.Add("MN", "Minnesota");
            states.Add("MS", "Mississippi");
            states.Add("MO", "Missouri");
            states.Add("MT", "Montana");
            states.Add("NE", "Nebraska");
            states.Add("NV", "Nevada");
            states.Add("NH", "New Hampshire");
            states.Add("NJ", "New Jersey");
            states.Add("NM", "New Mexico");
            states.Add("NY", "New York");
            states.Add("NC", "North Carolina");
            states.Add("ND", "North Dakota");
            states.Add("OH", "Ohio");
            states.Add("OK", "Oklahoma");
            states.Add("OR", "Oregon");
            states.Add("PA", "Pennsylvania");
            states.Add("RI", "Rhode Island");
            states.Add("SC", "South Carolina");
            states.Add("SD", "South Dakota");
            states.Add("TN", "Tennessee");
            states.Add("TX", "Texas");
            states.Add("UT", "Utah");
            states.Add("VT", "Vermont");
            states.Add("VA", "Virginia");
            states.Add("WA", "Washington");
            states.Add("WV", "West Virginia");
            states.Add("WI", "Wisconsin");
            states.Add("WY", "Wyoming");
            if (states.ContainsKey(abbr))
                return (states[abbr]);
            /* error handler is to return an empty string rather than throwing an exception */
            return "";
        }

        public static string AbbreviationStateExpand(string state)
        {
            Dictionary<string, string> states = new Dictionary<string, string>();

            states.Add("Alabama", "AL");
            states.Add("Alaska", "AK");
            states.Add("Arizona", "AZ");
            states.Add("Arkansas", "AR");
            states.Add("California", "CA");
            states.Add("Colorado", "CO");
            states.Add("Connecticut", "CT");
            states.Add("Delaware", "DE");
            states.Add("District of Columbia", "DC");
            states.Add("Florida", "FL");
            states.Add("Georgia", "GA");
            states.Add("Hawaii", "HI");
            states.Add("Idaho", "ID");
            states.Add("Illinois", "IL");
            states.Add("Indiana", "IN");
            states.Add("Iowa", "IA");
            states.Add("Kansas", "KS");
            states.Add("Kentucky", "KY");
            states.Add("Louisiana", "LA");
            states.Add("Maine", "ME");
            states.Add("Maryland", "MD");
            states.Add("Massachusetts", "MA");
            states.Add("Michigan", "MI");
            states.Add("Minnesota", "MN");
            states.Add("Mississippi", "MS");
            states.Add("Missouri", "MO");
            states.Add("Montana", "MT");
            states.Add("Nebraska", "NE");
            states.Add("Nevada", "NV");
            states.Add("New Hampshire", "NH");
            states.Add("New Jersey", "NJ");
            states.Add("New Mexico", "NM");
            states.Add("New York", "NY");
            states.Add("North Carolina", "NC");
            states.Add("North Dakota", "ND");
            states.Add("Ohio", "OH");
            states.Add("Oklahoma", "OK");
            states.Add("Oregon", "OR");
            states.Add("Pennsylvania", "PA");
            states.Add("Rhode Island", "RI");
            states.Add("South Carolina", "SC");
            states.Add("South Dakota", "SD");
            states.Add("Tennessee", "TN");
            states.Add("Texas", "TX");
            states.Add("Utah", "UT");
            states.Add("Vermont", "VT");
            states.Add("Virginia", "VA");
            states.Add("Washington", "WA");
            states.Add("West Virginia", "WV");
            states.Add("Wisconsin", "WI");
            states.Add("Wyoming", "WY");
            if (states.ContainsKey(state))
                return (states[state]);
            /* error handler is to return an empty string rather than throwing an exception */
            return "";
        }

        public static string CountryCodeExpand(string countryCode)
        {
            Dictionary<string, string> country = new Dictionary<string, string>();

            country.Add("AF", "Afghanistan");
            country.Add("AL", "Albania");
            country.Add("DZ", "Algeria");
            country.Add("AS", "American Samoa");
            country.Add("AD", "Andorra");
            country.Add("AO", "Angola");
            country.Add("AI", "Anguilla");
            country.Add("AQ", "Antarctica");
            country.Add("AG", "Antigua and Barbuda");
            country.Add("AR", "Argentina");
            country.Add("AM", "Armenia");
            country.Add("AW", "Aruba");
            country.Add("AU", "Australia");
            country.Add("AT", "Austria");
            country.Add("AZ", "Azerbaijan");
            country.Add("BS", "Bahamas");
            country.Add("BH", "Bahrain");
            country.Add("BD", "Bangladesh");
            country.Add("BB", "Barbados");
            country.Add("BY", "Belarus");
            country.Add("BE", "Belgium");
            country.Add("BZ", "Belize");
            country.Add("BJ", "Benin");
            country.Add("BM", "Bermuda");
            country.Add("BT", "Bhutan");
            country.Add("BO", "Bolivia");
            country.Add("BA", "Bosnia and Herzegovina");
            country.Add("BW", "Botswana");
            country.Add("BV", "Bouvet Island");
            country.Add("BR", "Brazil");
            country.Add("IO", "British Indian Ocean Territory");
            country.Add("BN", "Brunei Darussalam");
            country.Add("BG", "Bulgaria");
            country.Add("BF", "Burkina Faso");
            country.Add("BI", "Burundi");
            country.Add("KH", "Cambodia");
            country.Add("CM", "Cameroon");
            country.Add("CA", "Canada");
            country.Add("CV", "Cape Verde");
            country.Add("KY", "Cayman Islands");
            country.Add("CF", "Central African Republic");
            country.Add("TD", "Chad");
            country.Add("CL", "Chile");
            country.Add("CN", "China");
            country.Add("CX", "Christmas Island");
            country.Add("CC", "Cocos (Keeling) Islands");
            country.Add("CO", "Colombia");
            country.Add("KM", "Comoros");
            country.Add("CG", "Congo");
            country.Add("CD", "Congo, the Democratic Republic of the");
            country.Add("CK", "Cook Islands");
            country.Add("CR", "Costa Rica");
            country.Add("CI", "Cote D&#039;Ivoire");
            country.Add("HR", "Croatia");
            country.Add("CU", "Cuba");
            country.Add("CY", "Cyprus");
            country.Add("CZ", "Czech Republic");
            country.Add("DK", "Denmark");
            country.Add("DJ", "Djibouti");
            country.Add("DM", "Dominica");
            country.Add("DO", "Dominican Republic");
            country.Add("EC", "Ecuador");
            country.Add("EG", "Egypt");
            country.Add("SV", "El Salvador");
            country.Add("GQ", "Equatorial Guinea");
            country.Add("ER", "Eritrea");
            country.Add("EE", "Estonia");
            country.Add("ET", "Ethiopia");
            country.Add("FK", "Falkland Islands (Malvinas)");
            country.Add("FO", "Faroe Islands");
            country.Add("FJ", "Fiji");
            country.Add("FI", "Finland");
            country.Add("FR", "France");
            country.Add("GF", "French Guiana");
            country.Add("PF", "French Polynesia");
            country.Add("TF", "French Southern Territories");
            country.Add("GA", "Gabon");
            country.Add("GM", "Gambia");
            country.Add("GE", "Georgia");
            country.Add("DE", "Germany");
            country.Add("GH", "Ghana");
            country.Add("GI", "Gibraltar");
            country.Add("GR", "Greece");
            country.Add("GL", "Greenland");
            country.Add("GD", "Grenada");
            country.Add("GP", "Guadeloupe");
            country.Add("GU", "Guam");
            country.Add("GT", "Guatemala");
            country.Add("GN", "Guinea");
            country.Add("GW", "Guinea-Bissau");
            country.Add("GY", "Guyana");
            country.Add("HT", "Haiti");
            country.Add("HM", "Heard Island and Mcdonald Islands");
            country.Add("VA", "Holy See (Vatican City State)");
            country.Add("HN", "Honduras");
            country.Add("HK", "Hong Kong");
            country.Add("HU", "Hungary");
            country.Add("IS", "Iceland");
            country.Add("IN", "India");
            country.Add("ID", "Indonesia");
            country.Add("IR", "Iran, Islamic Republic of");
            country.Add("IQ", "Iraq");
            country.Add("IE", "Ireland");
            country.Add("IL", "Israel");
            country.Add("IT", "Italy");
            country.Add("JM", "Jamaica");
            country.Add("JP", "Japan");
            country.Add("JO", "Jordan");
            country.Add("KZ", "Kazakhstan");
            country.Add("KE", "Kenya");
            country.Add("KI", "Kiribati");
            country.Add("KP", "Korea, Democratic People&#039;s Republic of");
            country.Add("KR", "Korea, Republic of");
            country.Add("KW", "Kuwait");
            country.Add("KG", "Kyrgyzstan");
            country.Add("LA", "Lao People&#039;s Democratic Republic");
            country.Add("LV", "Latvia");
            country.Add("LB", "Lebanon");
            country.Add("LS", "Lesotho");
            country.Add("LR", "Liberia");
            country.Add("LY", "Libyan Arab Jamahiriya");
            country.Add("LI", "Liechtenstein");
            country.Add("LT", "Lithuania");
            country.Add("LU", "Luxembourg");
            country.Add("MO", "Macao");
            country.Add("MK", "Macedonia, the Former Yugoslav Republic of");
            country.Add("MG", "Madagascar");
            country.Add("MW", "Malawi");
            country.Add("MY", "Malaysia");
            country.Add("MV", "Maldives");
            country.Add("ML", "Mali");
            country.Add("MT", "Malta");
            country.Add("MH", "Marshall Islands");
            country.Add("MQ", "Martinique");
            country.Add("MR", "Mauritania");
            country.Add("MU", "Mauritius");
            country.Add("YT", "Mayotte");
            country.Add("MX", "Mexico");
            country.Add("FM", "Micronesia, Federated States of");
            country.Add("MD", "Moldova, Republic of");
            country.Add("MC", "Monaco");
            country.Add("MN", "Mongolia");
            country.Add("MS", "Montserrat");
            country.Add("MA", "Morocco");
            country.Add("MZ", "Mozambique");
            country.Add("MM", "Myanmar");
            country.Add("NA", "Namibia");
            country.Add("NR", "Nauru");
            country.Add("NP", "Nepal");
            country.Add("NL", "Netherlands");
            country.Add("AN", "Netherlands Antilles");
            country.Add("NC", "New Caledonia");
            country.Add("NZ", "New Zealand");
            country.Add("NI", "Nicaragua");
            country.Add("NE", "Niger");
            country.Add("NG", "Nigeria");
            country.Add("NU", "Niue");
            country.Add("NF", "Norfolk Island");
            country.Add("MP", "Northern Mariana Islands");
            country.Add("NO", "Norway");
            country.Add("OM", "Oman");
            country.Add("PK", "Pakistan");
            country.Add("PW", "Palau");
            country.Add("PS", "Palestinian Territory, Occupied");
            country.Add("PA", "Panama");
            country.Add("PG", "Papua New Guinea");
            country.Add("PY", "Paraguay");
            country.Add("PE", "Peru");
            country.Add("PH", "Philippines");
            country.Add("PN", "Pitcairn");
            country.Add("PL", "Poland");
            country.Add("PT", "Portugal");
            country.Add("PR", "Puerto Rico");
            country.Add("QA", "Qatar");
            country.Add("RE", "Reunion");
            country.Add("RO", "Romania");
            country.Add("RU", "Russian Federation");
            country.Add("RW", "Rwanda");
            country.Add("SH", "Saint Helena");
            country.Add("KN", "Saint Kitts and Nevis");
            country.Add("LC", "Saint Lucia");
            country.Add("PM", "Saint Pierre and Miquelon");
            country.Add("VC", "Saint Vincent and the Grenadines");
            country.Add("WS", "Samoa");
            country.Add("SM", "San Marino");
            country.Add("ST", "Sao Tome and Principe");
            country.Add("SA", "Saudi Arabia");
            country.Add("SN", "Senegal");
            country.Add("CS", "Serbia and Montenegro");
            country.Add("SC", "Seychelles");
            country.Add("SL", "Sierra Leone");
            country.Add("SG", "Singapore");
            country.Add("SK", "Slovakia");
            country.Add("SI", "Slovenia");
            country.Add("SB", "Solomon Islands");
            country.Add("SO", "Somalia");
            country.Add("ZA", "South Africa");
            country.Add("GS", "South Georgia and the South Sandwich Islands");
            country.Add("ES", "Spain");
            country.Add("LK", "Sri Lanka");
            country.Add("SD", "Sudan");
            country.Add("SR", "Suriname");
            country.Add("SJ", "Svalbard and Jan Mayen");
            country.Add("SZ", "Swaziland");
            country.Add("SE", "Sweden");
            country.Add("CH", "Switzerland");
            country.Add("SY", "Syrian Arab Republic");
            country.Add("TW", "Taiwan");
            country.Add("TJ", "Tajikistan");
            country.Add("TZ", "Tanzania, United Republic of");
            country.Add("TH", "Thailand");
            country.Add("TL", "Timor-Leste");
            country.Add("TG", "Togo");
            country.Add("TK", "Tokelau");
            country.Add("TO", "Tonga");
            country.Add("TT", "Trinidad and Tobago");
            country.Add("TN", "Tunisia");
            country.Add("TR", "Turkey");
            country.Add("TM", "Turkmenistan");
            country.Add("TC", "Turks and Caicos Islands");
            country.Add("TV", "Tuvalu");
            country.Add("UG", "Uganda");
            country.Add("UA", "Ukraine");
            country.Add("AE", "United Arab Emirates");
            country.Add("GB", "United Kingdom");
            country.Add("US", "United States");
            country.Add("UM", "United States Minor Outlying Islands");
            country.Add("UY", "Uruguay");
            country.Add("UZ", "Uzbekistan");
            country.Add("VU", "Vanuatu");
            country.Add("VE", "Venezuela");
            country.Add("VN", "Viet Nam");
            country.Add("VG", "Virgin Islands, British");
            country.Add("VI", "Virgin Islands, U.s.");
            country.Add("WF", "Wallis and Futuna");
            country.Add("EH", "Western Sahara");
            country.Add("YE", "Yemen");
            country.Add("ZM", "Zambia");
            country.Add("ZW", "Zimbabwe");
            if (country.ContainsKey(countryCode))
                return (country[countryCode]);
            /* error handler is to return an empty string rather than throwing an exception */
            return "";
        }

        public static string CountryCountryCodeExpand(string country)
        {
            Dictionary<string, string> countryCode = new Dictionary<string, string>();

            countryCode.Add("Afghanistan", "AF");
            countryCode.Add("Albania", "AL");
            countryCode.Add("Algeria", "DZ");
            countryCode.Add("American Samoa", "AS");
            countryCode.Add("Andorra", "AD");
            countryCode.Add("Angola", "AO");
            countryCode.Add("Anguilla", "AI");
            countryCode.Add("Antarctica", "AQ");
            countryCode.Add("Antigua and Barbuda", "AG");
            countryCode.Add("Argentina", "AR");
            countryCode.Add("Armenia", "AM");
            countryCode.Add("Aruba", "AW");
            countryCode.Add("Australia", "AU");
            countryCode.Add("Austria", "AT");
            countryCode.Add("Azerbaijan", "AZ");
            countryCode.Add("Bahamas", "BS");
            countryCode.Add("Bahrain", "BH");
            countryCode.Add("Bangladesh", "BD");
            countryCode.Add("Barbados", "BB");
            countryCode.Add("Belarus", "BY");
            countryCode.Add("Belgium", "BE");
            countryCode.Add("Belize", "BZ");
            countryCode.Add("Benin", "BJ");
            countryCode.Add("Bermuda", "BM");
            countryCode.Add("Bhutan", "BT");
            countryCode.Add("Bolivia", "BO");
            countryCode.Add("Bosnia and Herzegovina", "BA");
            countryCode.Add("Botswana", "BW");
            countryCode.Add("Bouvet Island", "BV");
            countryCode.Add("Brazil", "BR");
            countryCode.Add("British Indian Ocean Territory", "IO");
            countryCode.Add("Brunei Darussalam", "BN");
            countryCode.Add("Bulgaria", "BG");
            countryCode.Add("Burkina Faso", "BF");
            countryCode.Add("Burundi", "BI");
            countryCode.Add("Cambodia", "KH");
            countryCode.Add("Cameroon", "CM");
            countryCode.Add("Canada", "CA");
            countryCode.Add("Cape Verde", "CV");
            countryCode.Add("Cayman Islands", "KY");
            countryCode.Add("Central African Republic", "CF");
            countryCode.Add("Chad", "TD");
            countryCode.Add("Chile", "CL");
            countryCode.Add("China", "CN");
            countryCode.Add("Christmas Island", "CX");
            countryCode.Add("Cocos(Keeling) Islands", "CC");
            countryCode.Add("Colombia", "CO");
            countryCode.Add("Comoros", "KM");
            countryCode.Add("Congo", "CG");
            countryCode.Add("Congo, the Democratic Republic of the", "CD");
            countryCode.Add("Cook Islands", "CK");
            countryCode.Add("Costa Rica", "CR");
            countryCode.Add("Cote D&#039;Ivoire", "CI");
            countryCode.Add("Croatia", "HR");
            countryCode.Add("Cuba", "CU");
            countryCode.Add("Cyprus", "CY");
            countryCode.Add("Czech Republic", "CZ");
            countryCode.Add("Denmark", "DK");
            countryCode.Add("Djibouti", "DJ");
            countryCode.Add("Dominica", "DM");
            countryCode.Add("Dominican Republic", "DO");
            countryCode.Add("Ecuador", "EC");
            countryCode.Add("Egypt", "EG");
            countryCode.Add("El Salvador", "SV");
            countryCode.Add("Equatorial Guinea", "GQ");
            countryCode.Add("Eritrea", "ER");
            countryCode.Add("Estonia", "EE");
            countryCode.Add("Ethiopia", "ET");
            countryCode.Add("Falkland Islands (Malvinas)" ,"FK");
            countryCode.Add("Faroe Islands", "FO");
            countryCode.Add("Fiji", "FJ");
            countryCode.Add("Finland", "FI");
            countryCode.Add("France", "FR");
            countryCode.Add("French Guiana", "GF");
            countryCode.Add("French Polynesia", "PF");
            countryCode.Add("French Southern Territories", "TF");
            countryCode.Add("Gabon", "GA");
            countryCode.Add("Gambia", "GM");
            countryCode.Add("Georgia", "GE");
            countryCode.Add("Germany", "DE");
            countryCode.Add("Ghana", "GH");
            countryCode.Add("Gibraltar", "GI");
            countryCode.Add("Greece", "GR");
            countryCode.Add("Greenland", "GL");
            countryCode.Add("Grenada", "GD");
            countryCode.Add("Guadeloupe", "GP");
            countryCode.Add("Guam", "GU");
            countryCode.Add("Guatemala", "GT");
            countryCode.Add("Guinea", "GN");
            countryCode.Add("Guinea-Bissau", "GW");
            countryCode.Add("Guyana", "GY");
            countryCode.Add("Haiti", "HT");
            countryCode.Add("Heard Island and Mcdonald Islands", "HM");
            countryCode.Add("Holy See (Vatican City State),", "VA");
            countryCode.Add("Honduras", "HN");
            countryCode.Add("Hong Kong", "HK");
            countryCode.Add("Hungary", "HU");
            countryCode.Add("Iceland", "IS");
            countryCode.Add("India", "IN");
            countryCode.Add("Indonesia", "ID");
            countryCode.Add("Iran, Islamic Republic of", "IR");
            countryCode.Add("Iraq", "IQ");
            countryCode.Add("Ireland", "IE");
            countryCode.Add("Israel", "IL");
            countryCode.Add("Italy", "IT");
            countryCode.Add("Jamaica", "JM");
            countryCode.Add("Japan", "JP");
            countryCode.Add("Jordan", "JO");
            countryCode.Add("Kazakhstan", "KZ");
            countryCode.Add("Kenya", "KE");
            countryCode.Add("Kiribati", "KI");
            countryCode.Add("Korea, Democratic People&#039;s Republic of", "KP");
            countryCode.Add("Korea, Republic of", "KR");
            countryCode.Add("Kuwait", "KW");
            countryCode.Add("Kyrgyzstan", "KG");
            countryCode.Add("Lao People&#039;s Democratic Republic", "LA");
            countryCode.Add("Latvia", "LV");
            countryCode.Add("Lebanon", "LB");
            countryCode.Add("Lesotho", "LS");
            countryCode.Add("Liberia", "LR");
            countryCode.Add("Libyan Arab Jamahiriya", "LY");
            countryCode.Add("Liechtenstein", "LI");
            countryCode.Add("Lithuania", "LT");
            countryCode.Add("Luxembourg", "LU");
            countryCode.Add("Macao", "MO");
            countryCode.Add("Macedonia, the Former Yugoslav Republic of", "MK");
            countryCode.Add("Madagascar", "MG");
            countryCode.Add("Malawi", "MW");
            countryCode.Add("Malaysia", "MY");
            countryCode.Add("Maldives", "MV");
            countryCode.Add("Mali", "ML");
            countryCode.Add("Malta", "MT");
            countryCode.Add("Marshall Islands", "MH");
            countryCode.Add("Martinique", "MQ");
            countryCode.Add("Mauritania", "MR");
            countryCode.Add("Mauritius", "MU");
            countryCode.Add("Mayotte", "YT");
            countryCode.Add("Mexico", "MX");
            countryCode.Add("Micronesia, Federated States of", "FM");
            countryCode.Add("Moldova, Republic of", "MD");
            countryCode.Add("Monaco", "MC");
            countryCode.Add("Mongolia", "MN");
            countryCode.Add("Montserrat", "MS");
            countryCode.Add("Morocco", "MA");
            countryCode.Add("Mozambique", "MZ");
            countryCode.Add("Myanmar", "MM");
            countryCode.Add("Namibia", "NA");
            countryCode.Add("Nauru", "NR");
            countryCode.Add("Nepal", "NP");
            countryCode.Add("Netherlands", "NL");
            countryCode.Add("Netherlands Antilles", "AN");
            countryCode.Add("New Caledonia", "NC");
            countryCode.Add("New Zealand", "NZ");
            countryCode.Add("Nicaragua", "NI");
            countryCode.Add("Niger", "NE");
            countryCode.Add("Nigeria", "NG");
            countryCode.Add("Niue", "NU");
            countryCode.Add("Norfolk Island", "NF");
            countryCode.Add("Northern Mariana Islands", "MP");
            countryCode.Add("Norway", "NO");
            countryCode.Add("Oman", "OM");
            countryCode.Add("Pakistan", "PK");
            countryCode.Add("Palau", "PW");
            countryCode.Add("Palestinian Territory, Occupied", "PS");
            countryCode.Add("Panama", "PA");
            countryCode.Add("Papua New Guinea", "PG");
            countryCode.Add("Paraguay", "PY");
            countryCode.Add("Peru", "PE");
            countryCode.Add("Philippines", "PH");
            countryCode.Add("Pitcairn", "PN");
            countryCode.Add("Poland", "PL");
            countryCode.Add("Portugal", "PT");
            countryCode.Add("Puerto Rico", "PR");
            countryCode.Add("Qatar", "QA");
            countryCode.Add("Reunion", "RE");
            countryCode.Add("Romania", "RO");
            countryCode.Add("Russian Federation", "RU");
            countryCode.Add("Rwanda", "RW");
            countryCode.Add("Saint Helena", "SH");
            countryCode.Add("Saint Kitts and Nevis", "KN");
            countryCode.Add("Saint Lucia", "LC");
            countryCode.Add("Saint Pierre and Miquelon", "PM");
            countryCode.Add("Saint Vincent and the Grenadines", "VC");
            countryCode.Add("Samoa", "WS");
            countryCode.Add("San Marino", "SM");
            countryCode.Add("Sao Tome and Principe", "ST");
            countryCode.Add("Saudi Arabia", "SA");
            countryCode.Add("Senegal", "SN");
            countryCode.Add("Serbia and Montenegro", "CS");
            countryCode.Add("Seychelles", "SC");
            countryCode.Add("Sierra Leone", "SL");
            countryCode.Add("Singapore", "SG");
            countryCode.Add("Slovakia", "SK");
            countryCode.Add("Slovenia", "SI");
            countryCode.Add("Solomon Islands", "SB");
            countryCode.Add("Somalia", "SO");
            countryCode.Add("South Africa", "ZA");
            countryCode.Add("South Georgia and the South Sandwich Islands", "GS");
            countryCode.Add("Spain", "ES");
            countryCode.Add("Sri Lanka", "LK");
            countryCode.Add("Sudan", "SD");
            countryCode.Add("Suriname", "SR");
            countryCode.Add("Svalbard and Jan Mayen", "SJ");
            countryCode.Add("Swaziland", "SZ");
            countryCode.Add("Sweden", "SE");
            countryCode.Add("Switzerland", "CH");
            countryCode.Add("Syrian Arab Republic", "SY");
            countryCode.Add("Taiwan", "TW");
            countryCode.Add("Tajikistan", "TJ");
            countryCode.Add("Tanzania, United Republic of", "TZ");
            countryCode.Add("Thailand", "TH");
            countryCode.Add("Timor-Leste", "TL");
            countryCode.Add("Togo", "TG");
            countryCode.Add("Tokelau", "TK");
            countryCode.Add("Tonga", "TO");
            countryCode.Add("Trinidad and Tobago", "TT");
            countryCode.Add("Tunisia", "TN");
            countryCode.Add("Turkey", "TR");
            countryCode.Add("Turkmenistan", "TM");
            countryCode.Add("Turks and Caicos Islands", "TC");
            countryCode.Add("Tuvalu", "TV");
            countryCode.Add("Uganda", "UG");
            countryCode.Add("Ukraine", "UA");
            countryCode.Add("United Arab Emirates", "AE");
            countryCode.Add("United Kingdom", "GB");
            countryCode.Add("United States", "US");
            countryCode.Add("United States Minor Outlying Islands", "UM");
            countryCode.Add("Uruguay", "UY");
            countryCode.Add("Uzbekistan", "UZ");
            countryCode.Add("Vanuatu", "VU");
            countryCode.Add("Venezuela", "VE");
            countryCode.Add("Viet Nam", "VN");
            countryCode.Add("Virgin Islands, British", "VG");
            countryCode.Add("Virgin Islands, U.s.", "VI");
            countryCode.Add("Wallis and Futuna", "WF");
            countryCode.Add("Western Sahara", "EH");
            countryCode.Add("Yemen", "YE");
            countryCode.Add("Zambia", "ZM");
            countryCode.Add("Zimbabwe", "ZW");
            if (countryCode.ContainsKey(country))
                return (countryCode[country]);
            /* error handler is to return an empty string rather than throwing an exception */
            return "";
        }

        protected bool RecordExists(string tableName, string columnname, string criteria)
        {
            Table w3cTable = new Table(_driver.FindElement(By.Id(tableName)));
            return w3cTable.IsValuePresentWithinColumn(columnname, criteria);
        }

        public static long CountLinesInFile(string f)
        {
            long count = 0;
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    count++;
                }
            }
            return count;
        }

       
    }
}