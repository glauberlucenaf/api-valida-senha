namespace API.ValidaSenha.Models
{
    public class ValidaSenhaResult
    {
        public bool IsValid { get; set; }
        public List<string> erros { get; set; }
    }
}
