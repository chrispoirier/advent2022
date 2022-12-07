module Main where

import Control.Exception
import Data.List.Split
import Paths_part2

main :: IO ()
main = 
    do  inputContents <- readInputFile("input")
        --putStrLn inputContents
        let rangePairs = splitRanges(inputContents)
        --print $ rangePairs
        let count = containsCount(rangePairs)
        putStrLn ("Count: "++ show(count))

readInputFile :: String -> IO String
readInputFile name =
    handle(\(SomeException e) -> error("Error reading file:"++ name ++"\n"++ displayException e)) 
        (do filePath <- getDataFileName name
            readFile filePath
        )

splitRanges :: String -> [[[Int]]]
splitRanges contents = strToIntDeep(splitOnEachInner "-" (splitOnEach "," (splitOn "\n" contents)))
        

splitOnEach :: String -> [String] -> [[String]]
splitOnEach delim list = map (splitOn delim) list

splitOnEachInner :: String -> [[String]] -> [[[String]]]
splitOnEachInner delim list = map (map (splitOn delim)) list

strToIntDeep :: [[[String]]] -> [[[Int]]]
strToIntDeep list = map (map (map (strToInt))) list

strToInt :: String -> Int
strToInt str = 
    do  read str :: Int

containsCount :: [[[Int]]] -> Int
containsCount list = length (filter contains list)

contains :: [[Int]] -> Bool
contains ranges = 
    let range1 = ranges !! 0
        range2 = ranges !! 1
    in
        (range1 !! 1 >= range2 !! 0 && range1 !! 0 <= range2 !! 1) ||
        (range2 !! 1 >= range1 !! 0 && range2 !! 0 <= range1 !! 1)