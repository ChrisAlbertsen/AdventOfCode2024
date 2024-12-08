class GuardedMatrix {

    public char[][] matrix;
    int n;
    int m;
    public char[][] simulatedGuardedMatrix;
    Guard guard;

    public GuardedMatrix(char[][] matrix) {
        this.matrix = matrix;
        n = matrix.Length;
        m = matrix[0].Length;
        FindGuard('^');
    }

    public void FindGuard(char target) {
        for(int i = 0; i < matrix.Length; i++) {
            for(int j = 0; j < matrix[i].Length; j++) {
                if(matrix[i][j] == target) {
                    guard = new Guard(i,j,[-1,0]); //assuming guard will always go up
                    return;
                };
            }
        }
    }

    public bool CheckOutsideMatrix(int newRow, int newCol) {
        return newRow < 0 || newRow >= n || newCol < 0 || newCol >= m;
    }

    public char[][] CreateMatrixCopy(char[][] original) {
        char[][] copied = new char[original.Length][];
            
        for (int i = 0; i < original.Length; i++)
        {
            copied[i] = new char[original[i].Length];
            Array.Copy(original[i], copied[i], original[i].Length);
        }
        return copied;
    }

    public bool simulateMovement() {
        simulatedGuardedMatrix = CreateMatrixCopy(matrix);
        bool isInsideMatrix = true;
        int newRow;
        int newCol;
        int changedDirectionCounter;
        int guardLoopingCounter = 0;
        while(isInsideMatrix) {
            if(guardLoopingCounter == 4) return false;
            (newRow, newCol) = guard.NextMovement();
            if(CheckOutsideMatrix(newRow, newCol)) {
                isInsideMatrix = false;
                continue;
            }

            if(matrix[newRow][newCol] == '#') {
                changedDirectionCounter = 0;
                while(matrix[newRow][newCol] == '#') {
                    if(changedDirectionCounter == 4) throw new Exception("Changed direction more than 4 times");
                    guard.ChangeDirection();
                    (newRow, newCol) = guard.NextMovement();
                    changedDirectionCounter++;
                }
                if(CheckOutsideMatrix(newRow, newCol)) {
                    isInsideMatrix = false;
                    continue;
                }
                guardLoopingCounter++;
            }
            guard.Move();
            if(simulatedGuardedMatrix[guard.currentRow][guard.currentCol] == '.') guardLoopingCounter = 0;
            simulatedGuardedMatrix[guard.currentRow][guard.currentCol] = 'X';
        }
        return true;
    }
}
