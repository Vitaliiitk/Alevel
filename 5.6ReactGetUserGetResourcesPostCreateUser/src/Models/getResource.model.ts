import { ISupport } from "./support.model";
import { ISingleResource } from "./singleResource.model"; 

export interface IGetResource
{
    data: ISingleResource;
    support: ISupport;
}