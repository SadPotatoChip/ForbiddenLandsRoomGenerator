// See https://aka.ms/new-console-template for more information

using System.Text;


while (true)
{
    GenerateRoom();
    Console.ReadLine();
}


void GenerateRoom()
{
    var sb = new StringBuilder();

    var roomType = RollD6();
    switch (roomType)
    {
        case 1:
        case 2:
            sb.Append("Corridor\n");
            break;
        case 3:
        case 4:
            sb.Append("Room\n");
            sb.Append(GetRoomContentCombination(1));
            break;
        case 5:
            sb.Append("Hall\n");
            sb.Append(GetRoomContentCombination(2));
            break;
        case 6:
            sb.Append("Stairway\n");
            break;
    }
    
    var exitsRoll = RollD6();
    var exits = 0;
    switch (exitsRoll)
    {
        case 1:
        case 2:
            exits = 1;
            break;
        case 3:
            exits = 2;
            break;
        case 4:
            exits = 3;
            break;
        case 5:
            exits = 4;
            break;
        case 6:
            exits = 0;
            break;
    }

    sb.Append("\nDoors:\n");
    for (int i = 0; i < exits; i++)
    {
        sb.Append(GetDoor());
    }
    
    var itemRoll = RollD6();
    if (itemRoll >= 5)
    {
        sb.Append("Item: " + GetThing() );
        
    }

    sb.Append("\n------------------------------------------------");
    
    
    Console.WriteLine(sb.ToString());
}

string GetThing()
{
    var s = "";
    
    var roll = RollD6();
    switch (roll)
    {
        case 1:
            s="SARCOPHAGUS (" + (RollD6()<=2 ? "TRAPPED" : "") + ") (" + RollD66() + ")";
            break;
        case 2:
            s="CHEST (" + (RollD6()<=2 ? "TRAPPED" : "") + ") (Simple: " + RollD66() + ") (valuable: " + RollD66() + ")";
            break;
        case 3:
        case 4:
            s="SIMPLE FIND (" + RollD66() + ")";
            break;
        case 5:
        case 6:
            s="VALUABLE FIND (" + RollD66() + ")";
            break;
    }

    return s;
}

string GetDoor()
{
    var s = "";
    
    var roll = RollD6();
    switch (roll)
    {
        case 1:
            s="Open";
            break;
        case 2:
            s="Unlocked";
            break;
        case 3:
            s="Blocked";
            break;
        case 4:
        case 5:
            s="Locked";
            break;
        case 6:
            s="Locked and Trapped";
            break;
    }
    
    var roll2 = RollD6();
    if (roll2 >= 5)
    {
        s += " (leads to known location)";
    }

    return s + "\n";
}

string GetRoomContentCombination(int n)
{
    var s = "Contents: ";
    for (int i = 0; i < n; i++)
    {
        s += GetRoomContent() + ",";
    }
    return s.Remove(s.Length - 1, 1) + "\n";
}

string GetRoomContent()
{
    var roll = RollD6();
    switch (roll)
    {
        case 1:
        case 2:
        case 3:
            return "None";
        case 4:
        case 5:
            return "Monster";
        case 6:
            return "Trap (" + RollD66() +")";
        default:
            return "ERROR";
    }
}

int RollD6()
{
    return new Random().Next(6) + 1;
}

int RollD66()
{
    return RollD6() * 10 + RollD6();
}
