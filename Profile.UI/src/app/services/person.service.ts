import { Injectable } from "@angular/core";
import { ApiUrl } from "../shared/apiUrl";
import { HttpClient } from "@angular/common/http";
import { Person } from "../models/person"

@Injectable({
    providedIn: "root"
})
export class PersonService {
    private apiUrl = ApiUrl.BASE_URL + "person/"

    constructor(private http: HttpClient) { }

    getPerson() {
        return this.http.get<Person>(this.apiUrl);
    }

    updatePerson(person: Person) {
        return this.http.put(this.apiUrl + person.id, person);
    }
}