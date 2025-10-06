export class Education {
    institutionName: string = "";
    degree: string = "";
    fieldOfStudy: string = "";
    startDate: string = "";
    endDate: string = "";
    description: string = "";

    constructor(degree: string, institutionName: string, startDate: string, endDate: string, description: string) {
        this.degree = degree;
        this.institutionName = institutionName;
        this.startDate = startDate;
        this.endDate = endDate;
        this.description = description;
    }
}