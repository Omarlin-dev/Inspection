import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InspectionApiService {

  readonly inspectionApiUrl = "https://localhost:44357/api";

  constructor(private http: HttpClient) { }

  //Inspection

  getInspectionList(): Observable<any[]>{
    return this.http.get<any>(this.inspectionApiUrl + "/Inspection");
  }

  addInspection(data:any){
    return this.http.post(this.inspectionApiUrl + "/Inspection", data)
  }

  updateInspection(id: number|string, data: any){
      return this.http.put(this.inspectionApiUrl + `/Inspection/${id}`, data);
  }

  deleteInspection(id: number|string){
    return this.http.delete(this.inspectionApiUrl + `/Inspection/${id}`);
  }

  //Inspection Type

  getInspectionTypeList(): Observable<any[]>{
    return this.http.get<any>(this.inspectionApiUrl + "/InspectionType");
  }

  addInspectionType(data:any){
    return this.http.post(this.inspectionApiUrl + "/InspectionType", data)
  }

  updateInspectionType(id: number|string, data: any){
      return this.http.put(this.inspectionApiUrl + `/InspectionType/${id}`, data);
  }

  deleteInspectionType(id: number|string){
    return this.http.delete(this.inspectionApiUrl + `/InspectionType/${id}`);
  }

  //Status

  getStatusList(): Observable<any[]>{
    return this.http.get<any>(this.inspectionApiUrl + "/Status");
  }

  addStatus(data:any){
    return this.http.post(this.inspectionApiUrl + "/Status", data)
  }

  updateStatus(id: number|string, data: any){
      return this.http.put(this.inspectionApiUrl + `/Status/${id}`, data);
  }

  deleteStatus(id: number|string){
    return this.http.delete(this.inspectionApiUrl + `/Status/${id}`);
  }
}
