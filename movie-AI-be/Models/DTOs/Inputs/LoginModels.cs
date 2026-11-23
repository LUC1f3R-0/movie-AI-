using System.ComponentModel.DataAnnotations;

namespace movie_AI_BE.Models;

public sealed record LoginInput(
    [Required]
    [EmailAddress]
    string Email,

    [Required]
    string Password
);