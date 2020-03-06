namespace EncryptingLab_2
{
    public interface IEncrypt
    {
        void Encrypt();
        void Decrypt();
        void Print();
        string MainString { get; set; }
    }
}