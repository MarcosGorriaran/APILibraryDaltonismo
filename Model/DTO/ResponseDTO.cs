﻿namespace APILibraryDaltonismo.Model.DTO
{
    public class ResponseDTO<DataType>
    {
        public DataType? Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; } = "";

    }
}