export interface Job {
    name: string;
    description: string;
    level: Level;
    remuneration: number;
    skills: any[];
}

export enum Level {
    trainee = 1,
    junior = 2,
    full = 3,
    senior = 4,
}
