namespace Products.Configurations
{
    public static class CustomRoles
    {
        public const string Administrator = "Administrator";
        public const string Advanced = "Advanced";
        public const string Simple = "Simple";
        public const string AdministratorOrAdvanced = Administrator + "," + Advanced;
    }
}
