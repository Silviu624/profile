import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ApiUrl } from "../shared/apiUrl";
import { tap } from "rxjs";

@Injectable({
    providedIn: "root"
})
export class AuthService {
    private apiUrl = ApiUrl.BASE_URL;

    constructor(private http: HttpClient) { }

    public login(email: string, password: string) {
        return this.http.post<{ token: string }>(this.apiUrl + "login", { email, password })
            .pipe(tap(response => localStorage.setItem("access_token", response.token)));
    }

    public isLoggedIn(): boolean {
        return !!localStorage.getItem("access_token");
    }

    public logout(): void {
        localStorage.removeItem("access_token");
    }
}