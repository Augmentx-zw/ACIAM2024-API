namespace Ark.Gateway.API.BE.Services
{
    public interface IAESEnc
    {
        string USDEncrypt(string text);
        string RTGSEncrypt(string text);
        string USDDecrypt(string text);
        string RTGSDecrypt(string text);
    }
}
