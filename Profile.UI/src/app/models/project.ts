export class Project {
    id: string = "";
    name: string = "";
    description: string = "";
    github: string = "";
    technologies: string = "";

    constructor(id: string, name: string, description: string, github: string, technologies: string) {
        this.name = name;
        this.description = description;
        this.github = github;
        this.technologies = technologies;
    }
}