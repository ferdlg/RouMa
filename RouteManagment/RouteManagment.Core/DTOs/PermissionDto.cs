﻿namespace RouteManagment.Core.DTOs
{
    public class PermissionDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public bool IsDelete { get; set; }

    }
}
