use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

fn main() {
    let input = read_input("./input");
    //println!("Input: {:?}", input);
    let score = roshambo(input);

    println!("Score: {}", score);
}

fn read_input(filename : &str) -> Vec<[char;2]> {
    let mut rounds : Vec<[char; 2]> = Vec::new();

    if let Ok(lines) = read_lines(filename) {
        for line in lines {
            if let Ok(play_str) = line {
                let plays : Vec<&str> = play_str.split(' ').collect();
                rounds.push([plays[0].chars().next().unwrap(), plays[1].chars().next().unwrap()]);
            }
        }
    }

    return rounds;
}

fn read_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
where P: AsRef<Path>, {
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}

fn roshambo(input : Vec<[char; 2]>) -> u32 {
    let mut score: u32 = 0;

    for round in input {
        score += rsb_round(round);
    }

    return score;
}

fn rsb_round(input: [char;2]) -> u32 {
    let my_play_scores: [char; 3] = ['X', 'Y', 'Z'];
    let mut score: u32;

    match winner(input) {
        'M' => score = 6,
        'T' => score = 3,
        _ => score = 0
    }

    score += index_of(&my_play_scores, input[1]) + 1;

    return score;
}

fn index_of(arr: &[char], val: char) -> u32 {
    return u32::try_from(arr.iter().position(|&x| x == val).unwrap()).unwrap();
}

fn winner(play: [char;2]) -> char {
    match play {
        ['A','X'] | ['B', 'Y'] | ['C', 'Z'] => return 'T',
        ['A','Y'] | ['B', 'Z'] | ['C', 'X'] => return 'M',
        _ => return 'O'
    }
}