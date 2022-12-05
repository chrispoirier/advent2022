use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

fn main() {
    let input: Vec<[Vec<char>; 2]> = read_input("./input");
    //println!("Input: {:?}", input);
    let same: Vec<char> = find_all_same(input);
    //println!("Same: {:?}", same);
    println!("Score: {}", score(same));
}

fn read_input(filename : &str) -> Vec<[Vec<char>; 2]> {
    let mut packs : Vec<[Vec<char>; 2]> = Vec::new();

    if let Ok(lines) = read_lines(filename) {
        for line in lines {
            if let Ok(pack_str) = line {
                let (first, second) = pack_str.split_at(pack_str.len()/2);
                packs.push([first.chars().collect(), second.chars().collect()]);
            }
        }
    }

    return packs;
}

fn read_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
where P: AsRef<Path>, {
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}

fn find_all_same(input: Vec<[Vec<char>; 2]>) -> Vec<char> {
    let mut same: Vec<char> = Vec::new();

    for pack in input {
        let mut pack_same: Vec<char> = find_same(pack);
        //println!("Same found: {:?}", pack_same);
        same.append(&mut pack_same);
    }

    return same;
}

fn find_same(pack: [Vec<char>; 2]) -> Vec<char> {
    match pack[0].len() {
        0 => return Vec::new(),
        _ => {
            let comp1 = pack[0].split_first().unwrap().1.to_vec();
            let comp2 = &pack[1];
            if pack[1].contains(&pack[0][0]) {
                let mut same = find_same([comp1, comp2.to_vec()]);
                if !same.contains(&pack[0][0]) {
                    same.push(pack[0][0]);
                }
                return same;
            }
            else {
                return find_same([comp1, comp2.to_vec()]);
            }
        }
    }
}

fn score(same: Vec<char>) -> u32 {
    match same.len() {
        0 => return 0,
        _ => {
            let same_rest = same.split_first().unwrap().1.to_vec();
            return score(same_rest) + score_char(same[0]);
        }
    }
}

fn score_char(chr: char) -> u32 {
    let ascii = u32::try_from(chr).unwrap();
    if chr.is_lowercase() {
        return ascii - 96;
    }
    else {
        return score_char(chr.to_ascii_lowercase()) + 26;
    }
}