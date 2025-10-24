import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Review } from "../models/review";
import { ApiUrl } from "../shared/apiUrl";

@Injectable({
    providedIn: "root"
})
export class ReviewService {
    private apiUrl = ApiUrl.BASE_URL + 'review/';

    constructor(private http: HttpClient) { }

    public getReviews() {
        return this.http.get<Review[]>(this.apiUrl);
    }

    public addReview(review: Review) {
        return this.http.post(this.apiUrl, review);
    }

    public deleteReview(id: string) {
        return this.http.delete(this.apiUrl + id);
    }
}