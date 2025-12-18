export interface RaceForm {
  name: string;
  description: string;
  statModifier: {
    str: number;
    dex: number;
    cha: number;
    int: number;
    con: number;
    wis: number;
    mvt: number;
    maxHP: number;
    armorClass: number;
    hitModifier: number;
    initiative: number;
    spellAttack: number;
    spellSave: number;
  };
  traits: {
    name: string;
  }[];
  languages: {
    name: string;
  }[];
}
