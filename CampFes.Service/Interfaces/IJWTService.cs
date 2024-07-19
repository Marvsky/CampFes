namespace CampFes.Service.Interfaces
{
    public interface IJwtService
    {
        /// <summary>
        /// 產生JWT Token
        /// </summary>
        /// <returns></returns>
        public string GenJwtToken();

        /// <summary>
        /// 產生JWT Refresh Token
        /// </summary>
        /// <returns></returns>
        public string GenRefreshToken();

        /// <summary>
        /// 產生JWT Token
        /// </summary>
        /// <param name="user"></param>
        /// <param name="jti"></param>
        /// <returns></returns>
        string GenJwtToken(string user, string jti);
    }
}
