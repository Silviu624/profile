import { Injectable } from "@angular/core";
import { ApiUrl } from "../shared/apiUrl";
import { HttpClient } from "@angular/common/http";
import { Experience } from "../models/experience";

@Injectable({
    providedIn: 'root'
})
export class ExperienceService {
    private apiUrl = ApiUrl.BASE_URL + 'experience/';
    constructor(private http: HttpClient) { }

    getExperiences() {
        return this.http.get<Experience[]>(this.apiUrl);
    }

    deleteExperience(id: string) {
        return this.http.delete(this.apiUrl + id);
    }

    updateExperience(id: string, experience: Experience) {
        return this.http.put(this.apiUrl + id, experience);
    }

    addExperience(experience: Experience) {
        return this.http.post(this.apiUrl, experience);
    }
}