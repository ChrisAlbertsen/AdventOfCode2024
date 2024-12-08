class GuardedMatrixScenarioSimulator {
    public GuardedMatrix guardedMatrix;

    public GuardedMatrixScenarioSimulator(GuardedMatrix guardedMatrix){
        this.guardedMatrix = guardedMatrix;
    }
    
    public int detectGuardLoopingOpportunities(){
        if(guardedMatrix.simulatedGuardedMatrix == null) guardedMatrix.simulateMovement();
        
        (int rowIndex, int colIndex)[] patrolledIndexes = guardedMatrix.simulatedGuardedMatrix
            .SelectMany((row, rowIndex) =>
                row.Select((cell, colIndex) => new { cell, rowIndex, colIndex }))
            .Where(x => x.cell == 'X')
            .Select(x => (x.rowIndex, x.colIndex))
            .ToArray();

        int guardLoopsCreated = 0;
        
        int patrolledIndexesCounter = 1;
        int patrolledIndexesCount = patrolledIndexes.Length;
        foreach(var (row,col) in patrolledIndexes) {
            Console.WriteLine($"{patrolledIndexesCounter} / {patrolledIndexesCount}");
            GuardedMatrix guardedMatrixWithBlocker = new(DeepCopyMatrix(guardedMatrix.matrix));
            guardedMatrixWithBlocker.matrix[row][col] = '#';
            if(!guardedMatrixWithBlocker.simulateMovement()) guardLoopsCreated++;
            patrolledIndexesCounter++;
        }

        return guardLoopsCreated;
    }

    private char[][] DeepCopyMatrix(char[][] originalMatrix)
    {
        return originalMatrix.Select(row => row.ToArray()).ToArray();
    }
}