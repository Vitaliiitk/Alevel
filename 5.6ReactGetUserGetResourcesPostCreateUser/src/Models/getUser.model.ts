import { ISupport } from "./support.model";
import { IUser } from "./user.model";
import { ISingleResource } from "./singleResource.model"; 

export interface IGetUser
{
    data: IUser;
    support: ISupport;
    resource: ISingleResource;
}