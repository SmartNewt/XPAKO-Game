public class Cell
{
    public bool isGrass;
    public bool isDirt;
    public bool isShallowWater;
    public bool isDeepWater;
    public bool isStone; 

    public Cell(bool isGrass, bool isDirt, bool isShallowWater, bool isDeepWater, bool isStone) {
        this.isGrass = isGrass;
        this.isDirt = isDirt;
        this.isShallowWater = isShallowWater;
        this.isDeepWater = isDeepWater;
        this.isStone = isStone;
    }
}