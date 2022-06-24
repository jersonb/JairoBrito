using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JairoBrito.WebApp.Models;

[Table(name: "tb_message")]
public class MessageData
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; } = Guid.NewGuid();

    [MaxLength(50)]
    [Required]
    [Column("sender")]
    public string Sender { get; set; } = string.Empty;

    [MaxLength(200)]
    [Required]
    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [MaxLength(20)]
    [Required]
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [MaxLength(100)]
    [Required]
    [Column("subject")]
    public string Subject { get; set; } = string.Empty;

    [MaxLength(1000)]
    [Required]
    [Column("text")]
    public string Text { get; set; } = string.Empty;

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    [Column("answered")]
    public bool Answered { get; set; }

    [Column("answered_at")]
    public DateTimeOffset? AnsweredAt { get; set; }

    [MaxLength(1000)]
    [Column("answer")]
    public string? Answer { get; set; }
}