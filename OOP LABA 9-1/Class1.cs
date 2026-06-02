using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class Trans : IComparable
{
    public string ICON { get; set; }
    public int SPEED { get; set; }
    public string MARK { get; set; }
    public int NUMBER { get; set; }

    public string INFO { get; set; }
    public int MaxWeight { get; set; }

    protected abstract string GetInfo();
    public virtual string GetInfoString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Марка: {MARK}");
        sb.AppendLine($"Номер: {NUMBER}");
        sb.AppendLine($"Скорость: {SPEED} км/ч");
        sb.AppendLine($"Грузоподъемность: {GetLoadCapacity()} кг");
        return sb.ToString();
    }

    public abstract int GetLoadCapacity();
    public int CompareTo(object obj)
    {
        if (obj == null)
        {
            return 1;
        }
        else
        {
            Trans other = obj as Trans;
            return this.GetLoadCapacity().CompareTo(other.GetLoadCapacity());
        }
    }


    public Trans(string mark, int number, int speed, int maxWeight)
    {
        MARK = mark;
        NUMBER = number;
        SPEED = speed;
        MaxWeight = maxWeight;
    }
}

class Car : Trans
{
    public Car(string mark, int number, int speed, int maxWeight)
        : base(mark, number, speed, maxWeight)
    {
        this.INFO = this.GetInfo();
        this.ICON = "🚗";
    }

    public override int GetLoadCapacity()
    {
        return MaxWeight;
    }

    public override string GetInfoString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("=== ЛЕГКОВАЯ МАШИНА ===");
        sb.Append(base.GetInfoString());
        return sb.ToString();
    }
    protected override string GetInfo() => "";
}

class Motorcycle : Trans
{
    public bool HasSidecar { get; set; }

    public Motorcycle(string mark, int number, int speed, int maxWeight, bool hasSidecar)
        : base(mark, number, speed, maxWeight)
    {
        HasSidecar = hasSidecar;
        this.INFO = this.GetInfo();
        this.ICON = "🏍️";
    }

    public override int GetLoadCapacity()
    {
        if (!HasSidecar)
        {
            return 0;
        }
        return MaxWeight;
    }

    public override string GetInfoString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("=== МОТОЦИКЛ ===");
        sb.Append(base.GetInfoString());
        sb.AppendLine($"Наличие коляски: {(HasSidecar ? "Да" : "Нет")}");
        if (!HasSidecar)
        {
            sb.AppendLine("ВНИМАНИЕ: Грузоподъемность равна 0 (нет коляски)");
        }
        return sb.ToString();
    }

    protected override string GetInfo() => $"Наличие коляски: {(HasSidecar ? "Да" : "Нет")}";
}

class Truck : Trans
{
    public bool HasTrailer { get; set; }

    public Truck(string mark, int number, int speed, int maxWeight, bool hasTrailer)
        : base(mark, number, speed, maxWeight)
    {
        HasTrailer = hasTrailer;
        this.INFO = this.GetInfo();
        this.ICON = "🚛";
    }

    public override int GetLoadCapacity()
    {
        if (HasTrailer)
        {
            return MaxWeight * 2;
        }
        return MaxWeight;
    }

    public override string GetInfoString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("=== ГРУЗОВИК ===");
        sb.Append(base.GetInfoString());
        sb.AppendLine($"Наличие прицепа: {(HasTrailer ? "Да" : "Нет")}");
        if (HasTrailer)
        {
            sb.AppendLine("Грузоподъемность с прицепом увеличена в 2 раза");
        }
        return sb.ToString();
    }

    protected override string GetInfo() => $"Наличие прицепа: {(HasTrailer ? "Да" : "Нет")}";
}