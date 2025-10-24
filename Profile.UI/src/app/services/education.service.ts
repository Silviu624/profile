import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ApiUrl } from "../shared/apiUrl";
import { Education } from "../models/education";

@Injectable({
    providedIn: "root"
})
export class EducationService {
    private readonly apiUrl = ApiUrl.BASE_URL + "education/";
    constructor(private http: HttpClient) { }

    public getEducations() {
        return this.http.get<Education[]>(this.apiUrl);
    }

    public addEducation(education: Education) {
        return this.http.post<Education>(this.apiUrl, education);
    }

    public updateEducation(id: string, education: Education) {
        return this.http.put<Education>(this.apiUrl + id, education);
    }

    public deleteEducation(id: string) {
        return this.http.delete(this.apiUrl + id);
    }
}