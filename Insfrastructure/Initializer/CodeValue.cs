namespace Insfrastructure.Initialiser
{
    /// <summary>
    /// CodeValue
    /// </summary>
    public static class CodeValue
    {
        /// <summary>
        /// CRM
        /// </summary>
        /// 
        public static class CRM
        {
            
            public static class RendezVous
            {
                public const string CODE = "RDV";
                public const string ConsultRDV = "ConsultRDV";
            }
            public static class AlertSMS
            {
                public const string EvenementSMS = "EvenementSMS";
                public const string RappelRdvSMS = "RappelRdvSMS";
                public const string RappelGeneralSMS = "RappelGeneralSMS";
            }


        }
        
        public static class CCM
        {
            public const string CODE = "CCM";
            public static class ComplaintFeedBack
            {
                public const string CODE = "CCM_FB";
            }
            public static class FeedBackRpt
            {
                public const string CODE = "CCM_RPT_FB";
            }
            public static class ComplaintRpt
            {
                public const string CODE = "CCM_RPT_C";
            }

            public static class ComplaintRegistration
            {
                public const string CODE = "CCM_REG";
            }

            public static class ComplaintResolution
            {
                public const string CODE = "CCM_RES";
            }

            public static class ComplaintControlled
            {
                public const string CODE = "CCM_CTRL";
            }
        }
        
        /// <summary>
        /// Security
        /// </summary>
        public static class Security
        {
            /// <summary>
            /// Profile
            /// </summary>
            public static class Profile
            {
                /// <summary>
                /// Profile CODE
                /// </summary>
                public const string CODE = "PRC1";
                public const string ClASS_CODE = "EplC";
                public const string SUPER_ADMIN_PROFILE = "Super-Admin-FSInventory";
            }
            /// <summary>
            /// User
            /// </summary>
            public static class User
            {
                /// <summary>
                /// User CODE
                /// </summary>
                public const string CODE = "SUSR";
                public const string ProAvancedCODE = "APRF1";
                public const string SuspendedUser = "SuspendedUser";
                //public const string MenuCODE = "USR1";
            }

        }
        public static class Parameter
        {
            
            public const string COUNTRYCODE = "COUNTRYCODE";
            public const string REGIONCode = "REGIONCode";
            public const string DivisionCode = "DivisionCode";
            public const string SubDivision = "SubDivision";
            public static class Localization
            {
                public const string MenuCODE = "LOC";
            }
            

        }

    }

}

