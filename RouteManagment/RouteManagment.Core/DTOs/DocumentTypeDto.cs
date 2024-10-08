﻿namespace RouteManagment.Core.DTOs
{
    public class DocumentTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }
        public bool IsDelete { get; set; }

    }
}
