public class Clock : IEquatable<Clock>
{
    private int totalMinutes;

    public Clock(int hours, int minutes)
    {
        totalMinutes = ((hours * 60 + minutes) % 1440 + 1440) % 1440;
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(0, totalMinutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(0, totalMinutes - minutesToSubtract);
    }

    public override string ToString()
    {
        int hours = totalMinutes / 60;
        int minutes = totalMinutes % 60;
        return $"{hours:D2}:{minutes:D2}";
    }

    public bool Equals(Clock? other)
    {
        if (other is null) return false;
        return this.totalMinutes == other.totalMinutes;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Clock clock)
            return Equals(clock);
        return false;
    }

    public override int GetHashCode()
    {
        return totalMinutes.GetHashCode();
    }
}