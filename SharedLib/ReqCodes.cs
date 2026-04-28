namespace SharedLib
{
    public static class ReqCodes
    {
        public static readonly uint CodeSignIn = 100;
        public static readonly uint CodeRegister = 101;
        public static readonly uint CodeGetMovieById = 102;
        public static readonly uint CodeGetMovieByName = 103;
        public static readonly uint CodeGetAllMovies = 104;
        public static readonly uint CodeRentMovie = 105;
        public static readonly uint CodeReturnMovie = 106;
        public static readonly uint CodeGetRentedMovies = 107;
        public static readonly uint Ok = 200;
        public static readonly uint SuccessRent = 201;
        public static readonly uint ErrorSignIn = 401;
        public static readonly uint ErrorRegister = 402;
        public static readonly uint ErrorGettingMovie = 403;
        public static readonly uint Error = 404;
        public static readonly uint ErrorRent = 405;
    }
}