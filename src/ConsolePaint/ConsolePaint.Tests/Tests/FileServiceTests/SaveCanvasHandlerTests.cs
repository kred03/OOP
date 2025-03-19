using ConsolePaint.Models;
using Xunit;
using ConsolePaint.Services;
using System.IO;

namespace ConsolePaint.Tests.Tests.FileServiceTests
{
    public class SaveCanvasHandlerTests
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "canvas.txt");

        [Fact]
        public void SaveCanvas_ShouldCreateFile()
        {
            var fileService = new FileService();
            // Create some sample shapes to save
            var shapes = new Dictionary<string, Shape>
            {
                { "circle1", new Circle(5, '5', 3, 6, 'd') },  // Example circle (assuming Circle constructor matches)
                { "rectangle1", new Rectangle(5, 6, 'x', 2, 3, "Rectangle1", ' ') }  // Correct Rectangle constructor with 7 arguments
            };

            // Ensure the file is deleted before the test starts
            if (File.Exists(_filePath))
                File.Delete(_filePath);

            // Act: Save the shapes to a file
            fileService.SaveShapes(shapes);

            // Assert: Check if the file is created
            Assert.True(File.Exists(_filePath));
        }
    }
}