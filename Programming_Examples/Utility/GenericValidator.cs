namespace Programming_Examples.Utility
{
    public static class GenericValidator
    {
        public static bool Validate<T>(T entity) where T : class
        {
            if (entity == null)
            {
                return false;
            }

            return true;
        }
    }
}
