<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Item;
use Validator;
class ItemController extends Controller
{
	//商品を追加します
    public function store(Request $request){
    	$items = new Item($request->all());
    	$validated = Validator::make($request->all(),[
			"photo" =>"required|url",
  			"name" =>"required|unique:App\Models\Item|max:255",
  			"description"=>"required|string|min:1",
  			"price" =>"required|integer|min:1",
    	]);
    	if($validated->fails()){
    		return response(['message'=>'Bad Request'],400);
    	}
    	$items->save();
    	return response(["id"=>$items->id],201);
    }
    //商品の詳細を獲得します
    public function show($item_id){
    	$item = Item::find($item_id);
    	if(is_null($item)){
    		return response(['message'=>'Not Found'],404);
    	}
    	return response($item,200);
    }
    //商品を編集します
    public function update(Request $request,$item_id){
      	$validated = Validator::make($request->all(),[
			"photo" =>"url",
  			"name" =>"unique:App\Models\Item|max:255",
  			"description"=>"string|min:1",
  			"price" =>"integer|min:1",
    	]);
    	if($validated->fails()){
    		return response(['message'=>'Bad Request'],400);
    	}
    	$items = Item::find($item_id);
    	if(is_null($item_id)){
    		return response(['message'=>'Not Found'],404);
    	}
    	$items->fill($request->all())->save();
    	return response(null,204);
    }

    public function destroy($item_id){
    	$items = Item::find($item_id);
    	if(is_null($items)){
    		return response(['message'=>'Not Found'],404);
    	}
    	Item::destroy($item_id);
    	return response(null,204);
    }
}
