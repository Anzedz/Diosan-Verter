namespace Diosan_Verter;

// Factor = how many base units are in 1 of this unit
// Code is only used by Temperature
public record Unit(string Name, double Factor, string Code = "");

public static class ConverterData
{
    private static Unit U(string name, double factor) => new(name, factor);

    public static List<Unit> UnitsFor(string category) => category switch
    {
        // ---------- INFORMATION (base: byte) ----------
        "Information" => new()
        {
            U("Bit (b)", 0.125),
            U("Nibble", 0.5),
            U("Byte (B)", 1),

            U("Kilobit (kb)", 1000 / 8.0),
            U("Kibibit (Kib)", 1024 / 8.0),
            U("Megabit (Mb)", Math.Pow(1000, 2) / 8),
            U("Mebibit (Mib)", Math.Pow(1024, 2) / 8),
            U("Gigabit (Gb)", Math.Pow(1000, 3) / 8),
            U("Gibibit (Gib)", Math.Pow(1024, 3) / 8),
            U("Terabit (Tb)", Math.Pow(1000, 4) / 8),
            U("Tebibit (Tib)", Math.Pow(1024, 4) / 8),

            U("Kilobyte (kB)", 1000),
            U("Kibibyte (KiB)", 1024),
            U("Megabyte (MB)", Math.Pow(1000, 2)),
            U("Mebibyte (MiB)", Math.Pow(1024, 2)),
            U("Gigabyte (GB)", Math.Pow(1000, 3)),
            U("Gibibyte (GiB)", Math.Pow(1024, 3)),
            U("Terabyte (TB)", Math.Pow(1000, 4)),
            U("Tebibyte (TiB)", Math.Pow(1024, 4)),
            U("Petabyte (PB)", Math.Pow(1000, 5)),
            U("Pebibyte (PiB)", Math.Pow(1024, 5)),
            U("Exabyte (EB)", Math.Pow(1000, 6)),
            U("Exbibyte (EiB)", Math.Pow(1024, 6)),
        },

        // ---------- VOLUME (base: liter) ----------
        "Volume" => new()
        {
            U("Milliliter (mL)", 0.001),
            U("Centiliter (cL)", 0.01),
            U("Deciliter (dL)", 0.1),
            U("Liter (L)", 1),
            U("Cubic centimeter (cm³)", 0.001),
            U("Cubic meter (m³)", 1000),
            U("Cubic inch (in³)", 0.016387064),
            U("Cubic foot (ft³)", 28.316846592),
            U("Cubic yard (yd³)", 764.554857984),
            U("Teaspoon - US (tsp)", 0.00492892159375),
            U("Tablespoon - US (tbsp)", 0.01478676478125),
            U("Fluid ounce - US (fl oz)", 0.0295735295625),
            U("Cup - US", 0.2365882365),
            U("Pint - US (pt)", 0.473176473),
            U("Quart - US (qt)", 0.946352946),
            U("Gallon - US (gal)", 3.785411784),
            U("Fluid ounce - UK", 0.0284130625),
            U("Pint - UK", 0.56826125),
            U("Quart - UK", 1.1365225),
            U("Gallon - UK", 4.54609),
            U("Barrel - oil (bbl)", 158.987294928),
        },

        // ---------- LENGTH (base: meter) ----------
        "Length" => new()
        {
            U("Nanometer (nm)", 1e-9),
            U("Micrometer (µm)", 1e-6),
            U("Millimeter (mm)", 0.001),
            U("Centimeter (cm)", 0.01),
            U("Decimeter (dm)", 0.1),
            U("Meter (m)", 1),
            U("Kilometer (km)", 1000),
            U("Inch (in)", 0.0254),
            U("Foot (ft)", 0.3048),
            U("Yard (yd)", 0.9144),
            U("Mile (mi)", 1609.344),
            U("Fathom", 1.8288),
            U("Furlong", 201.168),
            U("Nautical mile (nmi)", 1852),
            U("Astronomical unit (AU)", 149597870700),
            U("Light-year (ly)", 9460730472580800),
        },

        // ---------- MASS (base: kilogram) ----------
        "Mass" => new()
        {
            U("Microgram (µg)", 1e-9),
            U("Milligram (mg)", 1e-6),
            U("Carat (ct)", 0.0002),
            U("Grain (gr)", 0.00006479891),
            U("Gram (g)", 0.001),
            U("Ounce (oz)", 0.028349523125),
            U("Pound (lb)", 0.45359237),
            U("Kilogram (kg)", 1),
            U("Stone (st)", 6.35029318),
            U("Metric ton (t)", 1000),
            U("Short ton - US", 907.18474),
            U("Long ton - UK", 1016.0469088),
        },

        // ---------- TEMPERATURE (handled with formulas) ----------
        "Temperature" => new()
        {
            new("Celsius (°C)", 1, "C"),
            new("Fahrenheit (°F)", 1, "F"),
            new("Kelvin (K)", 1, "K"),
            new("Rankine (°R)", 1, "R"),
            new("Réaumur (°Ré)", 1, "Re"),
        },

        // ---------- ENERGY (base: joule) ----------
        "Energy" => new()
        {
            U("Electronvolt (eV)", 1.602176634e-19),
            U("Joule (J)", 1),
            U("Kilojoule (kJ)", 1000),
            U("Megajoule (MJ)", 1e6),
            U("Calorie (cal)", 4.184),
            U("Kilocalorie (kcal)", 4184),
            U("Watt-hour (Wh)", 3600),
            U("Kilowatt-hour (kWh)", 3.6e6),
            U("BTU", 1055.05585262),
            U("Foot-pound (ft·lb)", 1.3558179483314),
            U("Therm - US", 105480400),
        },

        // ---------- AREA (base: square meter) ----------
        "Area" => new()
        {
            U("Square millimeter (mm²)", 1e-6),
            U("Square centimeter (cm²)", 1e-4),
            U("Square meter (m²)", 1),
            U("Hectare (ha)", 10000),
            U("Square kilometer (km²)", 1e6),
            U("Square inch (in²)", 0.00064516),
            U("Square foot (ft²)", 0.09290304),
            U("Square yard (yd²)", 0.83612736),
            U("Acre (ac)", 4046.8564224),
            U("Square mile (mi²)", 2589988.110336),
        },

        // ---------- SPEED (base: meter per second) ----------
        "Speed" => new()
        {
            U("Meter per second (m/s)", 1),
            U("Kilometer per hour (km/h)", 1 / 3.6),
            U("Mile per hour (mph)", 0.44704),
            U("Foot per second (ft/s)", 0.3048),
            U("Knot (kn)", 1852 / 3600.0),
            U("Mach (at sea level)", 340.29),
            U("Speed of light (c)", 299792458),
        },

        // ---------- DURATION (base: second) ----------
        "Duration" => new()
        {
            U("Nanosecond (ns)", 1e-9),
            U("Microsecond (µs)", 1e-6),
            U("Millisecond (ms)", 0.001),
            U("Second (s)", 1),
            U("Minute (min)", 60),
            U("Hour (h)", 3600),
            U("Day (d)", 86400),
            U("Week (wk)", 604800),
            U("Fortnight (2 weeks)", 1209600),
            U("Month (30 days)", 2592000),
            U("Year (365 days)", 31536000),
            U("Decade", 315360000),
            U("Century", 3153600000),
        },

        _ => new()
    };

    public static double Convert(string category, Unit from, Unit to, double value)
    {
        if (category == "Temperature") return ConvertTemperature(from.Code, to.Code, value);
        return value * from.Factor / to.Factor;
    }

    private static double ConvertTemperature(string from, string to, double v)
    {
        // step 1: anything -> Celsius
        double c = from switch
        {
            "F" => (v - 32) * 5 / 9,
            "K" => v - 273.15,
            "R" => (v - 491.67) * 5 / 9,
            "Re" => v * 5 / 4,
            _ => v
        };

        // step 2: Celsius -> target
        return to switch
        {
            "F" => c * 9 / 5 + 32,
            "K" => c + 273.15,
            "R" => (c + 273.15) * 9 / 5,
            "Re" => c * 4 / 5,
            _ => c
        };
    }
}