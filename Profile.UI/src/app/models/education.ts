export class Education {
    id: string = "";
    institutionName: string = "";
    degree: string = "";
    fieldOfStudy: string = "";
    startDate: string = "";
    endDate: string = "";
    description: string = "";

    constructor(id: string, degree: string, institutionName: string, startDate: string, endDate: string, description: string) {
        this.id = id;
        this.degree = degree;
        this.institutionName = institutionName;
        this.startDate = startDate;
        this.endDate = endDate;
        this.description = description;
    }
}