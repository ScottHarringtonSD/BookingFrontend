public class AddSuccess{

    public AddSuccess(){
        Id = string.Empty;
        Message = string.Empty;
    }

    public AddSuccess(string id, string message){
        Id = id;
        Message = message;
    }

    public string Id {get;set;}

    public string Message {get;set;}
}