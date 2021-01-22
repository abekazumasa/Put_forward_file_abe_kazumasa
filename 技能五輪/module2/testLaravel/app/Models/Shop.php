<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Shop extends Model
{

	protected $hidden =[
		'pivot',
	];
	protected $fillable =[
		'name',
		'photo',
		'opening_time',
		'closing_time',
		'price_range',
	];
	public function items(){
		return $this->belongsToMany('App\models\Item','shop_items');
	}
		public function getCreatedAtAttribute($date){
		$d = date_create($date);
		return date_format($d,'Y-m-d H:i:s');
	}
	public function getUpdatedAtAttribute($date){
		$d = date_create($date);
		return date_format($d,'Y-m-d H:i:s');
	}
    use HasFactory;
}
