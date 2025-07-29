public class ValidationError {
    private String message;
   
    protected ValidationError(String message) {
        this.message = message;
    }

    public static ValidationError InvalidDiceCountLength = 
        new ValidationError("Please specify at least two dice.");

    public static ValidationError InvalidFaceCount = 
        new ValidationError("The dice must have 6 faces.");    
        
    public override String ToString() {
        return String.Join("\n", 
            "Argument error.",
            message, 
            "Example: 1,2,3,4,5,6 1,2,3,4,5,6.");
    }    
}