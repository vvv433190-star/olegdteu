using System;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private T[] buffer;
    private int head; 
    private int tail; 
    private int count;

    public CircularBuffer(int capacity)
    {
        if (capacity <= 0) throw new ArgumentException("Capacity must be greater than 0.");
        buffer = new T[capacity];
        head = 0;
        tail = 0;
        count = 0;
    }

    public void Write(T value)
    {
        if (count == buffer.Length)
            throw new InvalidOperationException("Buffer is full.");
        
        buffer[tail] = value;
        tail = (tail + 1) % buffer.Length;
        count++;
    }

    public void Overwrite(T value)
    {
        if (count == buffer.Length)
        {
            buffer[head] = value;
            head = (head + 1) % buffer.Length;
            tail = head; 
        }
        else
        {
            Write(value);
        }
    }

    public T Read()
    {
        if (count == 0)
            throw new InvalidOperationException("Buffer is empty.");

        T value = buffer[head];
        buffer[head] = default(T);
        head = (head + 1) % buffer.Length;
        count--;
        return value;
    }

    public void Clear()
    {
        head = 0;
        tail = 0;
        count = 0;
        Array.Clear(buffer, 0, buffer.Length);
    }
}