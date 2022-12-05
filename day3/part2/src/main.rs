use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

fn main() {
    let input: Vec<Vec<Vec<char>>> = read_input("./input");
    //println!("Input: {:?}", input);
    let common: Vec<char> = find_all_common(input);
    //println!("Common: {:?}", common);
    println!("Score: {}", score(common));
}

fn read_input(filename : &str) -> Vec<Vec<Vec<char>>> {
    let mut packs : Vec<Vec<Vec<char>>> = Vec::new();

    if let Ok(lines) = read_lines(filename) {
        let mut group : Vec<Vec<char>> = Vec::new(); 
        for line in lines {
            if let Ok(pack_str) = line {
                group.push(pack_str.chars().collect());
            }
            if group.len() == 3 {
                packs.push(group);
                group = Vec::new();
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

fn find_all_common(input: Vec<Vec<Vec<char>>>) -> Vec<char> {
    let mut common: Vec<char> = Vec::new();

    for group in input {
        let mut group_common: Vec<char> = find_common(group);
        //println!("Common found: {:?}", group_common);
        common.append(&mut group_common);
    }

    return common;
}

fn find_common(group: Vec<Vec<char>>) -> Vec<char> {
    match group[0].len() {
        0 => return Vec::new(),
        _ => {
            let rest = group[0].split_first().unwrap().1.to_vec();
            let group1 = &group[1];
            let group2 = &group[2];
            if group[1].contains(&group[0][0]) && group[2].contains(&group[0][0]) {
                let mut common = find_common(vec![rest, group1.to_vec(), group2.to_vec()]);
                if !common.contains(&group[0][0]) {
                    common.push(group[0][0]);
                }
                return common;
            }
            else {
                return find_common(vec![rest, group1.to_vec(), group2.to_vec()]);
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