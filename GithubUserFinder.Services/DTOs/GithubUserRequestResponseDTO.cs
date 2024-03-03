using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubUserFinder.Services.DTOs
{
    public class GithubUserRequestResponseDTO
    {
        public bool IsSuccessStatusCode { get; set; }
        public string StatusCode { get; set; } = null!;
        public string? ErrorMessage { get; set; }
        public GithubUserDTO? GithubUser { get; set; }
    }
}
