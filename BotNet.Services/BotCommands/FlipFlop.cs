﻿using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BotNet.Services.ImageFlip;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotNet.Services.BotCommands {
	public static class FlipFlop {
		public static async Task HandleFlipAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken) {
			if (message.ReplyToMessage is null) {
				await botClient.SendTextMessageAsync(
					chatId: message.Chat.Id,
					text: "Apa yang mau diflip? Untuk ngeflip gambar, reply `/flip` ke pesan yang ada gambarnya\\.",
					parseMode: ParseMode.MarkdownV2,
					replyToMessageId: message.MessageId,
					cancellationToken: cancellationToken);
			} else if ((message.ReplyToMessage.Photo is null || message.ReplyToMessage.Photo.Length == 0)
				&& message.ReplyToMessage.Sticker is null) {
				await botClient.SendTextMessageAsync(
					chatId: message.Chat.Id,
					text: "Pesan ini tidak ada gambarnya\\. Untuk ngeflip gambar, reply `/flip` ke pesan yang ada gambarnya\\.",
					parseMode: ParseMode.MarkdownV2,
					replyToMessageId: message.MessageId,
					cancellationToken: cancellationToken);
			} else {
				using MemoryStream originalImageStream = new();
				Telegram.Bot.Types.File fileInfo = message.ReplyToMessage.Photo?.Length > 0
					? await botClient.GetInfoAndDownloadFileAsync(
						fileId: message.ReplyToMessage.Photo.OrderByDescending(photoSize => photoSize.Width).First().FileId,
						destination: originalImageStream,
						cancellationToken: cancellationToken)
					: await botClient.GetInfoAndDownloadFileAsync(
						fileId: message.ReplyToMessage.Sticker!.FileId,
						destination: originalImageStream,
						cancellationToken: cancellationToken);

				byte[] flippedImage = Flipper.FlipImage(originalImageStream.ToArray());
				using MemoryStream flippedImageStream = new(flippedImage);

				await botClient.SendPhotoAsync(
					chatId: message.Chat.Id,
					photo: new InputFileStream(flippedImageStream, new string(fileInfo.FileId.Reverse().ToArray()) + ".png"),
					replyToMessageId: message.ReplyToMessage.MessageId,
					cancellationToken: cancellationToken);
			}
		}

		public static async Task HandleFlopAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken) {
			if (message.ReplyToMessage is null) {
				await botClient.SendTextMessageAsync(
					chatId: message.Chat.Id,
					text: "Apa yang mau diflop? Untuk ngeflop gambar, reply `/flop` ke pesan yang ada gambarnya\\.",
					parseMode: ParseMode.MarkdownV2,
					replyToMessageId: message.MessageId,
					cancellationToken: cancellationToken);
			} else if ((message.ReplyToMessage.Photo is null || message.ReplyToMessage.Photo.Length == 0)
				&& message.ReplyToMessage.Sticker is null) {
				await botClient.SendTextMessageAsync(
					chatId: message.Chat.Id,
					text: "Pesan ini tidak ada gambarnya\\. Untuk ngeflop gambar, reply `/flop` ke pesan yang ada gambarnya\\.",
					parseMode: ParseMode.MarkdownV2,
					replyToMessageId: message.MessageId,
					cancellationToken: cancellationToken);
			} else {
				using MemoryStream originalImageStream = new();
				Telegram.Bot.Types.File fileInfo = message.ReplyToMessage.Photo?.Length > 0
					? await botClient.GetInfoAndDownloadFileAsync(
						fileId: message.ReplyToMessage.Photo.OrderByDescending(photoSize => photoSize.Width).First().FileId,
						destination: originalImageStream,
						cancellationToken: cancellationToken)
					: await botClient.GetInfoAndDownloadFileAsync(
						fileId: message.ReplyToMessage.Sticker!.FileId,
						destination: originalImageStream,
						cancellationToken: cancellationToken);

				byte[] floppedImage = Flipper.FlopImage(originalImageStream.ToArray());
				using MemoryStream floppedImageStream = new(floppedImage);

				await botClient.SendPhotoAsync(
					chatId: message.Chat.Id,
					photo: new InputFileStream(floppedImageStream, new string(fileInfo.FileId.Reverse().ToArray()) + ".png"),
					replyToMessageId: message.ReplyToMessage.MessageId,
					cancellationToken: cancellationToken);
			}
		}

		public static async Task HandleFlapAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken) {
			if (message.ReplyToMessage is null) {
				await botClient.SendTextMessageAsync(
					chatId: message.Chat.Id,
					text: "Apa yang mau diflap? Untuk ngeflap gambar, reply `/flap` ke pesan yang ada gambarnya\\.",
					parseMode: ParseMode.MarkdownV2,
					replyToMessageId: message.MessageId,
					cancellationToken: cancellationToken);
			} else if ((message.ReplyToMessage.Photo is null || message.ReplyToMessage.Photo.Length == 0)
				&& message.ReplyToMessage.Sticker is null) {
				await botClient.SendTextMessageAsync(
					chatId: message.Chat.Id,
					text: "Pesan ini tidak ada gambarnya\\. Untuk ngeflap gambar, reply `/flap` ke pesan yang ada gambarnya\\.",
					parseMode: ParseMode.MarkdownV2,
					replyToMessageId: message.MessageId,
					cancellationToken: cancellationToken);
			} else {
				using MemoryStream originalImageStream = new();
				Telegram.Bot.Types.File fileInfo = message.ReplyToMessage.Photo?.Length > 0
					? await botClient.GetInfoAndDownloadFileAsync(
						fileId: message.ReplyToMessage.Photo.OrderByDescending(photoSize => photoSize.Width).First().FileId,
						destination: originalImageStream,
						cancellationToken: cancellationToken)
					: await botClient.GetInfoAndDownloadFileAsync(
						fileId: message.ReplyToMessage.Sticker!.FileId,
						destination: originalImageStream,
						cancellationToken: cancellationToken);

				byte[] flappedImage = Flipper.FlapImage(originalImageStream.ToArray());
				using MemoryStream flappedImageStream = new(flappedImage);

				await botClient.SendPhotoAsync(
					chatId: message.Chat.Id,
					photo: new InputFileStream(flappedImageStream, new string(fileInfo.FileId.Reverse().ToArray()) + ".png"),
					replyToMessageId: message.ReplyToMessage.MessageId,
					cancellationToken: cancellationToken);
			}
		}

		public static async Task HandleFlepAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken) {
			if (message.ReplyToMessage is null) {
				await botClient.SendTextMessageAsync(
					chatId: message.Chat.Id,
					text: "Apa yang mau diflep? Untuk ngeflep gambar, reply `/flep` ke pesan yang ada gambarnya\\.",
					parseMode: ParseMode.MarkdownV2,
					replyToMessageId: message.MessageId,
					cancellationToken: cancellationToken);
			} else if ((message.ReplyToMessage.Photo is null || message.ReplyToMessage.Photo.Length == 0)
				&& message.ReplyToMessage.Sticker is null) {
				await botClient.SendTextMessageAsync(
					chatId: message.Chat.Id,
					text: "Pesan ini tidak ada gambarnya\\. Untuk ngeflep gambar, reply `/flep` ke pesan yang ada gambarnya\\.",
					parseMode: ParseMode.MarkdownV2,
					replyToMessageId: message.MessageId,
					cancellationToken: cancellationToken);
			} else {
				using MemoryStream originalImageStream = new();
				Telegram.Bot.Types.File fileInfo = message.ReplyToMessage.Photo?.Length > 0
					? await botClient.GetInfoAndDownloadFileAsync(
						fileId: message.ReplyToMessage.Photo.OrderByDescending(photoSize => photoSize.Width).First().FileId,
						destination: originalImageStream,
						cancellationToken: cancellationToken)
					: await botClient.GetInfoAndDownloadFileAsync(
						fileId: message.ReplyToMessage.Sticker!.FileId,
						destination: originalImageStream,
						cancellationToken: cancellationToken);

				byte[] fleppedImage = Flipper.FlepImage(originalImageStream.ToArray());
				using MemoryStream fleppedImageStream = new(fleppedImage);

				await botClient.SendPhotoAsync(
					chatId: message.Chat.Id,
					photo: new InputFileStream(fleppedImageStream, new string(fileInfo.FileId.Reverse().ToArray()) + ".png"),
					replyToMessageId: message.ReplyToMessage.MessageId,
					cancellationToken: cancellationToken);
			}
		}
	}
}
