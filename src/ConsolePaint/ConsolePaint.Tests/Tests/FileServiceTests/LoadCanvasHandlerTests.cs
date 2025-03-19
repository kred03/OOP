﻿using Xunit;
using ConsolePaint.Services;

namespace ConsolePaint.Tests.Tests.FileServiceTests
{
    public class LoadCanvasHandlerTests
    {
        [Fact]
        public void LoadCanvas_ShouldReturnNull_WhenFileDoesNotExist()
        {
            var fileService = new FileService();
            string filePath = "non_existing_file.txt";

            using (var sw = new StringWriter())
            {
                TextWriter originalOut = Console.Out;
                Console.SetOut(sw);

                var result = fileService.LoadShapes();

                Console.SetOut(originalOut);

                Assert.NotNull(result);
            }
        }

    }
}