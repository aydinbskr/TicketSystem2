import { ResponseModel } from "./responseModel";
import { Session } from "./session";

export interface SessionResponseModel extends ResponseModel{
    
    data:Session[]
    
}