<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Item extends Model
{
	protected $hidden=[
		'pivot',
	];
	protected $fillable =[
  "photo",
  "name",
  "description",
  "price",
	];
    use HasFactory;
}
