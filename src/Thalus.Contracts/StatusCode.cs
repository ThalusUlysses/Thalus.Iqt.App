namespace Thalus.Contracts
{
    public static class StatusCode
    {
        public const int OK = 200;
        public const int ResourceNotFound = 404;
        public const int AccessDenied = 403;

        public static bool IsError(int code)
        {
            if (code >= 300 || code > 200)
            {
                return true;
            }

            return true;
        }
    }
}


