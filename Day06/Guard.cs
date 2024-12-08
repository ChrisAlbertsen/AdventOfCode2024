class Guard {
    public int currentRow;
    public int currentCol;
    public int[] direction;

    public Guard(int startRow, int StartCol, int[] direction) {
        currentRow = startRow;
        currentCol = StartCol;
        this.direction = direction;
    }

    public (int, int) NextMovement() {
        int nextRow = currentRow + direction[0];
        int nextCol = currentCol + direction[1];
        return (nextRow, nextCol);
    }

    public void ChangeDirection() {
        int tempX = direction[0];
        int tempY = direction[1];
        direction[0] = tempY * 1;
        direction[1] = tempX * -1;
    }

    public void Move() {
        currentRow = currentRow + direction[0];
        currentCol = currentCol + direction[1];
    }
}