import { Injectable } from "@angular/core";
import { ApiUrl } from "../shared/apiUrl";
import { HttpClient } from "@angular/common/http";
import { Project } from "../models/project";

@Injectable({
    providedIn: 'root'
})
export class ProjectService {
    private apiUrl = ApiUrl.BASE_URL + 'project/';

    constructor(private http: HttpClient) { }

    getProjects() {
        return this.http.get<Project[]>(this.apiUrl);
    }

    deleteProject(id: string) {
        return this.http.delete(this.apiUrl + id);
    }

    updateProject(id: string, project: Project) {
        return this.http.put(this.apiUrl + id, project);
    }

    addProject(project: Project) {
        return this.http.post(this.apiUrl, project);
    }
}