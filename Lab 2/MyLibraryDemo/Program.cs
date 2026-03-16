using MyLibrary;

var colors = new[] { "Red", "Green", "Blue" };
var gen = Generator.ColorCycleGenerator(colors); 
ColorProcessor.ConsumeWithTimeout(gen, 5);
