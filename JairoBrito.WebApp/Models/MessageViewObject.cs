using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JairoBrito.WebApp.Models;

public class MessageViewObject
{
    public MessageViewObject()
    {
        Name = string.Empty;
        Email = string.Empty;
        PhoneNumber = string.Empty;
        Subject = string.Empty;
        Text = string.Empty;
    }

    [DisplayName("Nome")]
    [Required(ErrorMessage = "Informe seu nome")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Informe seu nome")]
    public string Name { get; set; }

    [DisplayName("Email")]
    [Required(ErrorMessage = "Informe seu email")]
    [RegularExpression(@"^([a-zA-Z]+([\.-_]?[a-zA-z0-9]+)*)\@([a-zA-Z0-9]+)([-][0-9a-z]+)?\.([a-z-]{2,20})(\.[a-z]{2,3})?$", ErrorMessage = "Informe seu email")]
    public string Email { get; set; }

    [DisplayName("Telefone")]
    [Required(ErrorMessage = "Informe seu telefone")]
    [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{1}?[\s-]?\d{4}?[\s-]?\d{3,4}", ErrorMessage = "Informe seu telefone")]
    public string PhoneNumber { get; set; }

    [DisplayName("Assunto")]
    [Required(ErrorMessage = "Informe o assunto")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Informe o assunto")]
    public string Subject { get; set; }

    [DisplayName("Deixe Sua Mensagem")]
    [Required(ErrorMessage = "Informe a mensagem")]
    [StringLength(1000, MinimumLength = 2, ErrorMessage = "Informe a mensagem")]
    public string Text { get; set; }

}