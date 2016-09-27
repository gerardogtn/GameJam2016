using UnityEngine;
using System.Collections;

static class ColorsOperations {

	public static Colors Add(this Colors first, Colors second) {
		switch (first) {
		case Colors.Black:
			return second;
		case Colors.Cyan:
			if (second == Colors.Red) {
				return Colors.White;
			} else {
				return Colors.Cyan;
			}
		case Colors.Magenta: 
			if (second == Colors.Green) {
				return Colors.White; 
			} else {
				return Colors.Magenta;
			}
		case Colors.Yellow: 
			if (second == Colors.Blue) {
				return Colors.White;
			} else {
				return Colors.Yellow;
			}
		case Colors.Red: 
			if (second == Colors.Green) {
				return Colors.Yellow;
			} else if (second == Colors.Blue) {
				return Colors.Magenta; 
			} else if (second == Colors.Cyan) {
				return Colors.White;
			} else {
				return second;
			}
		case Colors.Green:
			if (second == Colors.Red) {
				return Colors.Yellow;
			} else if (second == Colors.Blue) {
				return Colors.Cyan;
			} else if (second == Colors.Magenta) {
				return Colors.White; 
			} else {
				return second;
			}
		case Colors.Blue: 
			if (second == Colors.Red) {
				return Colors.Magenta;
			} else if (second == Colors.Green) {
				return Colors.Cyan; 
			} else if (second == Colors.Yellow) {
				return Colors.White;
			} else {
				return second;
			}
		default:
			return Colors.Black;
		}
	}

	public static Colors Remove(this Colors first, Colors second) {
		switch (first) {
		case Colors.Black:
			return Colors.Black;
		case Colors.Red: 
			if (second == Colors.Red) {
				return Colors.Black;
			} else {
				return Colors.Red;
			}
		case Colors.Green: 
			if (second == Colors.Green) {
				return Colors.Black; 
			} else {
				return Colors.Green;
			}
		case Colors.Blue: 
			if (second == Colors.Blue) {
				return Colors.Black;
			} else {
				return Colors.Blue;
			}
		case Colors.Yellow: 
			if (second == Colors.Red) {
				return Colors.Green; 
			} else if (second == Colors.Green) {
				return Colors.Red;
			} else if (second == Colors.Yellow) {
				return Colors.Black; 
			} else {
				return Colors.Yellow;
			}
		case Colors.Magenta: 
			if (second == Colors.Red) {
				return Colors.Blue;
			} else if (second == Colors.Blue) {
				return Colors.Red; 
			} else if (second == Colors.Magenta) {
				return Colors.Black;
			} else {
				return Colors.Magenta;
			}
		case Colors.Cyan: 
			if (second == Colors.Blue) {
				return Colors.Green; 
			} else if (second == Colors.Green) {
				return Colors.Blue;
			} else if (second == Colors.Cyan) {
				return Colors.Black;
			} else {
				return Colors.Cyan;
			}
		case Colors.White: 
			if (second == Colors.Red) {
				return Colors.Cyan; 
			} else if (second == Colors.Green) {
				return Colors.Magenta; 
			} else if (second == Colors.Blue) {
				return Colors.Yellow;
			} else if (second == Colors.Cyan) {
				return Colors.Red; 
			} else if (second == Colors.Magenta) {
				return Colors.Green; 
			} else if (second == Colors.Yellow) {
				return Colors.Blue; 
			} else if (second == Colors.White) {
				return Colors.Black; 
			} else {
				return Colors.White; 
			}
		default:
			return Colors.Black;
		}
	}

	public static string getString(this Colors color) {
		switch (color) {
		case Colors.Red:
			return "Red";
		case Colors.Green:
			return "Green";
		case Colors.Blue: 
			return "Blue";
		case Colors.Cyan: 
			return "Cyan"; 
		case Colors.Yellow:
			return "Yellow";
		case Colors.Magenta: 
			return "Magenta";
		case Colors.Black: 
			return "Black";
		case Colors.White: 
			return "White";
		default: 
			return "Unknown color"; 
		}
	}
}
